namespace Models.Converters.ToDoList
{
    using System;
    using Model = global:: Models.ToDoList;
    using Client = global::Client.Models.ToDoList;

    class ToDoUpdateInfoConverter
    {
        public static Model.ToDoUpdateInfo Convert(int Id, Client.ToDoUpdateInfo clientUpdInfo)
        {
            if (clientUpdInfo == null)
            {
                throw new ArgumentNullException(nameof(clientUpdInfo));
            }

            var modelUpdInfo = new Model.ToDoUpdateInfo(Id)
            {
                IsDone = clientUpdInfo.IsDone,
                Text = clientUpdInfo.Text
            };

            return modelUpdInfo;
        }
    }
}
