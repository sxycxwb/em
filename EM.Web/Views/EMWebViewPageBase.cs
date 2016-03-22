using Abp.Web.Mvc.Views;

namespace EM.Web.Views
{
    public abstract class EMWebViewPageBase : EMWebViewPageBase<dynamic>
    {

    }

    public abstract class EMWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected EMWebViewPageBase()
        {
            LocalizationSourceName = EMConsts.LocalizationSourceName;
        }
    }
}