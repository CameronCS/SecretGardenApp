using System;

namespace APIHandler {


    public class NewsLetter {
        private string _id;
        public string ID {
            get => _id;
            set => _id = value;
        }

        private string title;
        public string Title {
            get => title;
            set => title = value;
        }

        private string description;
        public string Description {
            get => description;
            set => description = value;
        }

        private DateTime date;
        public DateTime Date {
            get => date;
            set => date = value;
        }

        private string classId;
        public string ClassID {
            get => classId;
            set => classId = value;
        }

        private string imageUrl;
        public string ImageUrl {
            get => imageUrl;
            set => imageUrl = value;
        }

        private DateTime createdAt;
        public DateTime CreatedAt {
            get => createdAt;
            set => createdAt = value;
        }

        public NewsLetter(string id, string title, string description, DateTime date, string classId, string imageUrl, DateTime createdAt) {
            ID = id;
            Title = title;
            Description = description;
            Date = date;
            ClassID = classId;
            ImageUrl = imageUrl;
            CreatedAt = createdAt;
        }
    }
}