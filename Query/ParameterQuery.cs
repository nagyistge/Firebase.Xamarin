namespace Firebase.Xamarin.Query
{
    /// <summary>
    /// Represents a parameter in firebase query, e.g. "?data=foo"
    /// </summary>
    public abstract class ParameterQuery : FirebaseQuery
    {
        private readonly string parameter;
        private readonly string separator;

		protected ParameterQuery(FirebaseQuery parent, string parameter)
			: base(parent)
		{
			this.parameter = parameter;

			if (parent.BuildUrl().IndexOf('?') > 0)
			{
				this.separator = "&";
			}
			else
			{ 
				this.separator = (this.Parent is ChildQuery) ? "?" : "&";
			}
		}

        protected override string BuildUrlSegment(FirebaseQuery child)
        {
            return $"{this.separator}{this.parameter}={this.BuildUrlParameter(child)}";
        }

        protected abstract string BuildUrlParameter(FirebaseQuery child);
    }
}
