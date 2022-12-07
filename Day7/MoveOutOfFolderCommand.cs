using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7;

public class MoveOutOfFolderCommand : ICommands
{
    private int repeat = 1;

    public MoveOutOfFolderCommand(int repeat)
    {
        this.repeat = repeat;
    }

    public void Execute()
    {
        for (int i = 0; i < repeat; i++)
        {
            Parser.GoUpOneFolder();
        }
    }
}
