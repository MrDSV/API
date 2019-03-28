namespace Models.Converters.ToDoList
{
    using System;
    using Model = global::Models.ToDoList;
    using Client = global::Client.Models.ToDoList;

    public static class ToDoInfoConverter
    {
        public static Client.ToDoInfo Convert(Model.ToDoInfo modelToDoInfo)
        {
            if (modelToDoInfo == null)
            {
                throw new ArgumentException(nameof(modelToDoInfo));
            }

            var clientToDoInfo = new Client.ToDoInfo
            {
                Id = modelToDoInfo.Id.ToString(),
                UserId = modelToDoInfo.UserId,
                IsDone = modelToDoInfo.IsDone,
                CreatedAt = modelToDoInfo.CreatedAt,
                LastUpdatedAt = modelToDoInfo.LastUpdatedAt
            };

            return clientToDoInfo;
        }
    }
}
