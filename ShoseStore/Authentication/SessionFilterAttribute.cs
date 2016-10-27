using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ShoseStore.Authentication
{
    /**
     * cái lớp ActionFilterAttribute này nek là cái lớp dùng để tạo các attribute dành cho các action method của
     * controller
     * Cái lớp trên đố sẽ luôn chạy trước khi cái action method chạy
     * Mình extend để lấy những tính chất đó, 
     * rùi override cái phương thức mình càn để tạo ra custom hành vi mà mình muốn
     */
    public class SessionFilterAttribute: ActionFilterAttribute
    {
        /**
         * base: =super
         * ActionExecutingContext: là cái bối cảnh của cái action method đang được thực thi
         * nếu là index thì là bối cảnh của index, nếu là create thì là của create
         * HttpContext: là cái bối cảnh chung cho tất cả
         */
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            HttpContext context = HttpContext.Current;
            var adminname = context.Session["adminname"];
            if(adminname == null)
            {
                //ý là chuyển cái bối cảnh hiện tại sẽ trả về là login
                filterContext.Result = new RedirectResult("/Admin/Login");
                return;
            }
        }
    }
}