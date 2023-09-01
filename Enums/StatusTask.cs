

using System.ComponentModel;

namespace Enums
{
    public enum StatusTask
    {
        [Description("a Fazer")]
        Doing = 1,

        [Description("Em andamento")]
        Progress = 2,

        [Description("Concluído")]
        Completed = 3

    }
}
