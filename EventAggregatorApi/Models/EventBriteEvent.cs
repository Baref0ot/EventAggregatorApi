namespace EventAggregatorApi.Models {
    public class EventBriteEvent {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; } // Assuming you store it as a plain string
        public string Url { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
        public DateTime? Published { get; set; } // Nullable since it might not be published yet
        public string Status { get; set; }
        public string Currency { get; set; }
        public bool OnlineEvent { get; set; }
        public bool HideStartDate { get; set; }
        public bool HideEndDate { get; set; }
    }
}
