using SERVICE.Dtos.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DATA.Extensions;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System;
using DATA.Enums;

namespace MAIN
{
    public class MainControllerBase : ControllerBase
    {
        private const int DEFAULT_ROW_PER_PAGE = 20;
        public MainControllerBase() {}

        public long CurrentUserId
        {
            get
            {
                var currentUserId = User.Claims.Where(c => c.Subject.NameClaimType == JwtRegisteredClaimNames.Sub)
                    .FirstOrDefault()
                    .Value;

                return long.Parse(currentUserId);
            }
        }

        public long CurrentShopId
        {
            get
            {
                long currentCustomerSalonId = long.Parse(User.Claims.Where(c => c.Type == "ShopId")
                    .FirstOrDefault()
                    .Value);

                return currentCustomerSalonId;
            }
        }

        public long CurrentShopBranchId
        {
            get
            {
                long currentCustomerSalonId = long.Parse(User.Claims.Where(c => c.Type == "ShopBranchId")
                    .FirstOrDefault()
                    .Value);

                return currentCustomerSalonId;
            }
        }

        public string CurrentUserEmail
        {
            get
            {
                return User.Claims.Where(c => c.Type == "Email")
                    .FirstOrDefault()
                    .Value;
            }
        }

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

        public dynamic OKException(Exception exception)
        {
            return exception.Message switch
            {
                nameof(EXCEPTION_TYPE.NOT_FOUND) => NotFound(),
                nameof(EXCEPTION_TYPE.NO_CONTENT) => NoContent(),
                nameof(EXCEPTION_TYPE.FORBID) => Forbid(),
                _ => BadRequest(exception.Message),
            };
        }

        public OkObjectResult Ok<TData>(ActionResultDto<TData> value)
        {
            return new OkObjectResult(value);
        }

        public override OkObjectResult Ok(object value)
        {
            if (value is ActionResultDto)
            {
                return new OkObjectResult(value);
            }

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
