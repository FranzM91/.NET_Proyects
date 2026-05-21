namespace google.server.Entity
{
    public class Usuario: IEntity
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string studentcode { get; set; }
        public virtual string ip { get; set; }
        public virtual bool status { get; set; }
        public virtual DateTime created_at { get; set; }
        public virtual DateTime? updated_at { get; set; }
    }
}
