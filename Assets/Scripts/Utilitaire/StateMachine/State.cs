using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface State
{
    void update();

    void fixedUpdate();

    void enterState(State previousState);

    void leaveState();
}
