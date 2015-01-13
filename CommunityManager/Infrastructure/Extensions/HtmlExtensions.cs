using System;
using System.Web.Mvc;
using System.Linq.Expressions;

namespace CommunityManager.Infrastructure.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString DescriptionFor<TModel, TValue>(this HtmlHelper<TModel> self, Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, self.ViewData);
            var description = metadata.Description;

            return MvcHtmlString.Create(string.Format(@"<span class='field-info-description'>{0}</span>", description));
        }
    }
}