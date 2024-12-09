using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentCommunication.Shared
{
    public class ControlMovingMan : ControlBase
    {
        public override void OnKeyDown(KeyboardEventArgs e)
        {
            switch (e.Key)
            {
                case "Home":
                    EnqueueInput(ConsoleKey.Home);
                    break;
                case "End":
                    EnqueueInput(ConsoleKey.End);
                    break;
                case "Backspace":
                    EnqueueInput(ConsoleKey.Backspace);
                    break;
                case " ":
                    EnqueueInput(ConsoleKey.Spacebar);
                    break;
                case "Delete":
                    EnqueueInput(ConsoleKey.Delete);
                    break;
                case "Enter":
                    EnqueueInput(ConsoleKey.Enter);
                    break;
                case "Escape":
                    EnqueueInput(ConsoleKey.Escape);
                    break;
                case "ArrowLeft":
                    EnqueueInput(ConsoleKey.LeftArrow);
                    break;
                case "ArrowRight":
                    EnqueueInput(ConsoleKey.RightArrow);
                    break;
                case "ArrowUp":
                    EnqueueInput(ConsoleKey.UpArrow);
                    break;
                case "ArrowDown":
                    EnqueueInput(ConsoleKey.DownArrow);
                    break;
                case ".":
                    EnqueueInput(ConsoleKey.OemPeriod);
                    break;
                case "-":
                    EnqueueInput(ConsoleKey.OemMinus);
                    break;
                default:
                    if (e.Key.Length is 1)
                    {
                        var c = e.Key[0];
                        switch (c)
                        {
                            case >= '0' and <= '9':
                                EnqueueInput(ConsoleKey.D0 + (c - '0'));
                                break;
                            case >= 'a' and <= 'z':
                                EnqueueInput(ConsoleKey.A + (c - 'a'));
                                break;
                            case >= 'A' and <= 'Z':
                                EnqueueInput(ConsoleKey.A + (c - 'A'), true);
                                break;
                        }
                    }

                    break;
            }
        }

        public override void EnqueueInput(ConsoleKey key, bool shift = false, bool alt = false, bool control = false)
        {
            var c = key switch
            {
                >= ConsoleKey.A and <= ConsoleKey.Z => (char)(key - ConsoleKey.A + 'a'),
                >= ConsoleKey.D0 and <= ConsoleKey.D9 => (char)(key - ConsoleKey.D0 + '0'),
                ConsoleKey.Enter => '\n',
                ConsoleKey.Backspace => '\b',
                ConsoleKey.OemPeriod => '.',
                ConsoleKey.OemMinus => '-',
                _ => '\0'
            };
            base.InputBuffer.Enqueue(new ConsoleKeyInfo(shift ? char.ToUpper(c) : c, key, shift, alt, control));
        }
    }
}
