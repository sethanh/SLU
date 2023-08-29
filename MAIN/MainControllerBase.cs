using MAIN.Dtos.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DATA.Extensions;
using System.Linq;

namespace MAIN
{
    public class MainControllerBase : ControllerBase
    {
        private const int DEFAULT_ROW_PER_PAGE = 20;

        public int Page
        {
            get
            {
                int.TryParse(HttpContext.Request.Query["page"].ToString(), out int page);
                return page > 0 ? page : 1;
            }
        }

        public int RowPerPage
        {
            get
            {
                int.TryParse(HttpContext.Request.Query["rowPerPage"].ToString(), out int rowPerPage);
                return rowPerPage == 0 ? DEFAULT_ROW_PER_PAGE : rowPerPage;
            }
        }

        public string OrderBy
        {
            get => HttpContext.Request.Query["orderBy"].ToString();
        }

        public string OrderType
        {
            get
            {
                var orderType = HttpContext.Request.Query["orderType"].ToString();
                if (string.IsNullOrEmpty(orderType))
                {
                    return "desc";
                }
                return orderType;
            }
        }

        public MainControllerBase() { }

        public override OkObjectResult Ok(object value)
        {
            var response = new ActionResultDto
            {
                Data = value,
            };

            return new OkObjectResult(response);
        }

        public IQueryable<T> ApplyPagination<T>(IQueryable<T> rs)
        {
            if (!string.IsNullOrEmpty(OrderBy))
            {
                rs = rs.OrderByField(OrderBy, OrderType);
            }
            var data = rs.Skip((Page - 1) * RowPerPage).Take(RowPerPage);

            return data;
        }

        public IEnumerable<T> ApplyPagination<T>(IEnumerable<T> rs)
        {
            var data = rs.Skip((Page - 1) * RowPerPage).Take(RowPerPage);

            return data;
        }

        public List<T> ApplyPagination<T>(List<T> data)
        {
            var pageData = data.Skip((Page - 1) * RowPerPage).Take(RowPerPage).ToList();
            return pageData;
        }

        public OkObjectResult OkList<T>(IQueryable<T> rs)
        {
            var response = new ActionResultDto
            {
                Data = this.ApplyPagination(rs).ToList(),
                Meta = new ActionResultMetaDto
                {
                    TotalItem = rs.Count()
                }
            };

            return new OkObjectResult(response);
        }

        public OkObjectResult OkList<T>(IEnumerable<T> rs)
        {
            var response = new ActionResultDto
            {
                Data = this.ApplyPagination(rs).ToList(),
                Meta = new ActionResultMetaDto
                {
                    TotalItem = rs.Count()
                }
            };

            return new OkObjectResult(response);
        }

        public OkObjectResult OkList<T>(List<T> rs)
        {
            var response = new ActionResultDto
            {
                Data = this.ApplyPagination(rs),
                Meta = new ActionResultMetaDto
                {
                    TotalItem = rs.Count()
                }
            };

            return new OkObjectResult(response);
        }

        public override CreatedAtActionResult CreatedAtAction(string actionName, object routeValues, object value)
        {
            var response = new ActionResultDto
            {
                Data = value
            };
            return this.CreatedAtAction(actionName, null, routeValues, response);
        }
    }
}
