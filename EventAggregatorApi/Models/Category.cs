

namespace EventAggregatorApi.Models {
    public class Category {

        public string Id { get; set; }


        public string Resource_Uri { get; set; }


        public string Name { get; set; }


        public string Name_Localized { get; set; }


        public string Short_Name { get; set; }


        public string Short_Name_Localized { get; set; }
    }// end Category


    public class CategoryResponse {
        public List<Category> Categories { get; set; }
    }// end Categories
}
