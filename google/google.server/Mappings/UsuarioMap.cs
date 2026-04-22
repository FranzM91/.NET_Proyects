using FluentNHibernate.Mapping;
using google.server.Entity;

namespace google.server.Mappings
{
    public class UsuarioMap: ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("usuario");
            Id(x => x.id).Column("usuario_Id").CustomType<int>()
                    .GeneratedBy.Custom<global::NHibernate.Id.IdentityGenerator>()
                    .UnsavedValue(null);
            Map(x => x.name);
            Map(x => x.email);
            Map(x => x.password);
            Map(x => x.created_at);
            Map(x => x.updated_at);
        }
    }
}
