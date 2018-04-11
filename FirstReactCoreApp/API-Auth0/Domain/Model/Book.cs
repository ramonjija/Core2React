namespace API_Auth0.Domain.Model
{
    public class Book
    {
        
        private string _author;
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private bool _ageRestriction;
        public bool AgeRestriction
        {
            get { return _ageRestriction; }
            set { _ageRestriction = value; }
        }
        
        public Book(string Author, string Title, bool AgeRestriction)
        {
            this._author = Author;
            this._title = Title;
            this._ageRestriction = AgeRestriction;
        }
    }
}
