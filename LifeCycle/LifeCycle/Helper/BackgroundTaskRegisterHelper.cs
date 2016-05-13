using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace LifeCycle.Helper
{
    public class BackgroundTaskRegisterHelper
    {
        public static BackgroundTaskRegistration RegisterBackgroundTask(string taskEntryPoint,
                                                                        string name,
                                                                        IBackgroundTrigger trigger,
                                                                        IEnumerable<IBackgroundCondition> conditions)
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks) {
                if (task.Value.Name == name) {
                    return (BackgroundTaskRegistration)task.Value;
                }
            }

            var builder = new BackgroundTaskBuilder();

            builder.Name = name;
            builder.TaskEntryPoint = taskEntryPoint;
            builder.SetTrigger(trigger);

            if (conditions != null) {
                foreach(var condition in conditions)
                    builder.AddCondition(condition);
            }

            return builder.Register();
        }
    }
}
