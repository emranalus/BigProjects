namespace KitaplikMVC_DAL.Abstract
{

    public enum State
    {
        Active,
        Passive
    }

    public abstract class BaseEntity
    {

        public int Id { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public State State { get; set; }

    }
}
