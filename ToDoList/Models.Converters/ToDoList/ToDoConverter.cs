namespace Models.Converters.ToDoList
{
    using System;
    using Model = global::Models.ToDoList;
    using Client = global::Client.Models.ToDoList;

    public static class ToDoConverter
    {
        public static Client.ToDo Convert(Model.ToDo modelToDo)
        {
            if (modelToDo == null)
            {
                throw new ArgumentNullException(nameof(modelToDo));
            }

            var clientToDo = new Client.ToDo
            {
                Id = modelToDo.Id.ToString(),
                UserId = modelToDo.UserId,
                Text = modelToDo.Text,
                IsDone = modelToDo.IsDone,
                CreatedAt = modelToDo.CreatedAt,
                LastUpdatedAt = modelToDo.LastUpdatedAt
            };

            return clientToDo;
        }
    }
}
