namespace LocalGems.ViewModels
{
    public class UserType
    {
		private string _IsSelected;

		public string IsSelected
		{
			get { return _IsSelected; }
			set { _IsSelected = value; }
		}

		private string _Value;

		public string Value
		{
			get { return _Value; }
			set { _Value = value; }
		}

        public UserType(string value)
        {
            Value = value;
        }
    }
}