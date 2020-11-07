using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;

namespace APIEdux.Repositories
{
    public class UrlImagemRepository : Repository<UrlImagem>, IUrlImagemRepository
    {

        public UrlImagemRepository(EduxContext context) : base(context) { }

    }
}