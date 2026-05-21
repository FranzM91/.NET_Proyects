using FluentNHibernate.Mapping;
using google.server.Entity;

namespace google.server.Mappings
{
    public class UsuarioMap: ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("usuario");
            Id(x => x.id).Column("usuario_id")
                    .GeneratedBy.Identity();

            Map(x => x.name).Column("name");
            Map(x => x.studentcode).Column("studentcode");
            Map(x => x.status).Column("status");
            Map(x => x.ip).Column("ip");
            Map(x => x.created_at).Column("created_at");
            Map(x => x.updated_at).Column("updated_at").Nullable();
        }
    }
}
