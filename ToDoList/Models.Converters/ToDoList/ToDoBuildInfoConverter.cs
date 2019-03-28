namespace Models.Converters.ToDoList
{
    using System;
    using Model = global::Models.ToDoList;
    using Client = global::Client.Models.ToDoList;

    public class ToDoBuildInfoConverter
    {
        public static Model.ToDoCreationInfo Convert(string clientUserId, Client.ToDoBuildInfo clientBuildInfo)
        {
            if (clientUserId == null)
            {
                throw new ArgumentNullException(nameof(clientUserId));
            }

            if (clientBuildInfo == null)
            {
                throw new ArgumentNullException(nameof(clientBuildInfo));
            }

            var modelCreationInfo = new Model.ToDoCreationInfo(clientUserId, clientBuildInfo.Text);

            return modelCreationInfo;
        }
    }
}
