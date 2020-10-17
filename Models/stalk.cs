namespace Models
{
    /**
     * this stalk class include attributes of the shopped clothes
     * Attributes are id, which is the primary key
     * Type of item added to the stalk such as leggings and tops
     * the cost of purchasing the item and the description
    */
    public class stalk
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
    }
}