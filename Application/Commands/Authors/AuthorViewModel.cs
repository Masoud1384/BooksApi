using Application.Services;

namespace Application.Commands.Authors
{
    public class AuthorViewModel : UpdateAuthorCommand
    {
        public List<ApiLink> links = new List<ApiLink>();
    }
}
