namespace Application
{
    public class ApiLink
    {
        public string Hrref { get; set; }
        public string Relationship { get; set; }
        public string Method { get; set; }
        public ApiLink()
        {

        }
        public ApiLink(string hrref, string relationship, string method)
        {
            Hrref = hrref;
            Relationship = relationship;
            Method = method;
        }
    }
