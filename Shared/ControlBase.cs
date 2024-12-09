using Microsoft.AspNetCore.Components.Web;

namespace ComponentCommunication.Shared
{
    public class ControlBase : IKeyControl
    {
        /// <summary>
        /// 按键序列缓冲区
        /// </summary>
        public readonly Queue<ConsoleKeyInfo> InputBuffer = new();

        /// <summary>
        /// 获取页面按键
        /// </summary>
        /// <param name="e"></param>
        public virtual void OnKeyDown(KeyboardEventArgs e) {}

        /// <summary>
        /// 将特定的 ConsoleKey 及其附加修饰符（如 Shift、Alt 和 Control）转换为 ConsoleKeyInfo 对象，
        /// 并将其放入一个输入缓冲区（InputBuffer）中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="shift">false</param>
        /// <param name="alt">false</param>
        /// <param name="control">false</param>
        public virtual void EnqueueInput(ConsoleKey key, bool shift = false, bool alt = false, bool control = false) {}
    }
}
