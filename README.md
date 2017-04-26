# T14-probable-system





WHAT?

A proof of concept for
A lean and mean, robust, reliable,  maintainable, extendable, explainable, pleasant looking desktop application.

WHY?
======



 - Because I did not find widely accepted receipt how to do it .
 - Because it is  possible today with tool and technologies we have.
 - Because I want have set of known compatible packages in one place
   along with basic project structure.  
 - Because The basic 3-layer project structure is made of just 200 lines of code.
 - Because I hate to write excuses.
 - Because people calling me when i.e. the USB stack of camera driver
   return device specific error code or asynchronous exception leaks out
   and leave a business transaction in doubt. And I understand those
   good fault in-tolerant people - They call me because the only contact
   they indirectly have is main.

HOW?
======

Refactor specific  functionality as [command](https://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=91), [queries and events](https://www.cuttingedge.it/blogs/steven/pivot/entry.php?id=92), 
send command and queries (i.e with [rebus](https://github.com/rebus-org/Rebus)) over reliable message ques to command, queries and long running transaction processors hosted in separate process and receive outcome as reports and events. Then implement them with simple focused components, delegate general functionality to the general purpose components and  wire all those components with DI container.


ALSO
======
To demonstrate certain competency and skills with present day  technologies in software development.



