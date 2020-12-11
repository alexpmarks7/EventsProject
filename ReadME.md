## Events Project

An events application using Visual Studio, C#, SQL and Entity Framework  



## *Table of Contents*

1. [Project Goal](#Project%20Goal)
2. [Definition of Done](#Definition_of_Done)
3. [User Definition of Done](#User_Definition_of_Done)
4. [Sprint One](<#Sprint One>)
5. [Sprint Two](#Sprint_Two)
6. [Sprint Three](#Sprint_Three)
7. [Project_Retrospective](#Project_Retrospective)



## *Project Goal*

*To build a 3 tier application that manages events bookings.  Functionality to sell tickets, add and remove events, update event information, and ensure events don't oversell their capacity*.



## *Definition_of_Done*

- [x] Database is generated and populated
- [x] All MVP Project User Stories have been coded to be functional
- [ ] All code is tested and refactored   (*code is tested, but didn't manage to refactor*)

- [x] GUI front end is usable and interacts with all CRUD operations, and is bug free

- [x] Code is well commented and readable

- [ ] Product has been reviewed and approved

- [x] Class diagram is updated

- [x] ReadME.md file is written and clear

- [x] All documentation is uploaded to GitHub

- [ ] Presentation is well planned and ready to be delivered

  

## *User_Definition_of_Done*

- [ ] The criteria for the story is met
- [ ] The code is fully tested
- [ ] The GUI interacts with the code
- [ ] Code is reviewed
- [ ] Progress is documented



## *Sprint One*

***Sprint One Goals**

- [x] Add acceptance criteria to this sprints user stories

 - [x] Database created and events added

 - [x] Business layer interacts with DB

 - [x] Methods written to add and remove venues from DB

 - [x] Above methods well tested

 - [x] GUI created with basic functionality working

 - [x] All code is well commented

 - [x] Documentation is up-to-date and uploaded to GitHub

   

*Sprint Review*

- sprint goal was achieved
- all selected user stories were completed
- all tests passing
- basic GUI is functional
  - one known bug: crashes when "Edit venue" button is pressed with no venue selected
- documentation is up to date



*Sprint Retrospective*

- the sprint started slowly but progressed well, with a implementable GUI performing the methods required

- more functionality could have been added to the business layer, to create a more "complete" GUI, closer to the expected final product'

- methods written thus far function as planned, with successful GUI interaction

- planning and building the database was not trouble free.  Database may have to be redesigned in a further sprint

- GUI layer needs better direction as to how it's final appearance will be - this required more thought and planning from the start

- code could be refactored in places

  

## *Sprint_Two*

**Sprint Two Goals**

 - [x] Add acceptance criteria to this sprints user stories. Be more explicit with user stories

 - [x] Plan vision for how completed GUI needs to look

 - [x] Complete commenting not finished during sprint one

 - [x] Review testing from sprint one, and ensure tests are complete

 - [x] Add the sport type and music genre tables to my database

 - [x] Methods written to add, remove and edit events

 - [x] Ensure event methods interact with venues (an event needs a venue!)

 - [x] GUI is updated to interact with event functionality

 - [ ] Refactor code

 - [ ] Ensure GUI runs completely bug free

 - [ ] Document all bugs, and when debugged

 - [ ] All code is well commented

 - [x] Documentation is up-to-date and uploaded to GitHub

   

*Sprint Review*

- sprint goal was not fully achieved
- all selected user stories were completed
- all tests passing
- database was updated and provides a far better base to develop the app on
- refactoring still needed, some debugging needed, some code could be better commented
- GUI is nearly complete, functionality is good, bar a couple of bugs
- documentation is up to date



*Sprint Retrospective*

- the sprint was successful, the extra weekend time was made good sue of
- all methods written so far function well, with good GUI interaction
- happy with the database, though in future iterations of the project would like to further develop the DB
- GUI layers design was better planned out, and plans were put into place successfully
- code could be refactored, but MVP should be achieved by the end of sprint 3
- need to remember to document bugs, before and after fixed.  Will try to better implement in sprint 3



## *Sprint_Two*

**Sprint Two Goals**

 - [x] Add acceptance criteria to this sprints user stories. Be more explicit with user stories

 - [x] Plan vision for how completed GUI needs to look

 - [x] Complete commenting not finished during sprint one

 - [x] Review testing from sprint one, and ensure tests are complete

 - [x] Add the sport type and music genre tables to my database

 - [x] Methods written to add, remove and edit events

 - [x] Ensure event methods interact with venues (an event needs a venue!)

 - [x] GUI is updated to interact with event functionality

 - [ ] Refactor code

 - [ ] Ensure GUI runs completely bug free

 - [ ] Document all bugs, and when debugged

 - [ ] All code is well commented

 - [x] Documentation is up-to-date and uploaded to GitHub

   

*Sprint Review*

- sprint goal was not fully achieved
- all selected user stories were completed
- all tests passing
- database was updated and provides a far better base to develop the app on
- refactoring still needed, some debugging needed, some code could be better commented
- GUI is nearly complete, functionality is good, bar a couple of bugs
- documentation is up to date



*Sprint Retrospective*

- the sprint was successful, the extra weekend time was made good use of
- all methods written so far function well, with good GUI interaction
- happy with the database, though in future iterations of the project would like to further develop the DB
- GUI layers design was better planned out, and plans were put into place successfully
- code could be refactored, but MVP should be achieved by the end of sprint 3
- need to remember to document bugs, before and after fixed.  Will try to better implement in sprint 3



## Sprint_Three

**Sprint Three Goals**

 - [x] Add acceptance criteria to this sprints user stories

 - [x] Methods for ticket sales added

 - [x] Methods are well tested

 - [x] GUI interacts with new methods

 - [ ] Code refactored

 - [x] GUI runs bug free

 - [x] All bugs documented

 - [x] Documentation is up-to-date and pushed to Github

 - [ ] Presentation is planned with colleagues

   

*Sprint Review*

- only sprint goal not achieved was the refactoring of the code
- all selected user stories were completed
- all tests passing
- GUI was improved, better aesthetic and all functionality works
- all bugs debugged and tested
- code is commented
- documentation is up to date and pushed to GitHub



*Sprint Retrospective*

- the sprint was successful
- happy with the functionality of the methods and the GUI and DB interaction in the app
- would have liked to have refactored the code, but time did not permit.  There is duplicate code, and areas where code could be better written
- happy with having MVP by end of sprint three
- bug identification and debugging documentation was far better
- didn't manage to implement any of the further methods from the "Further Functionality Project Backlog"



## **Project_Retrospective**

**What went well:**

- MVP was achieved
- GUI layer is functional, and all methods implement interact with business and database layer successfully
- all CRUD funtions were tested
- documentation was kept up-to-date throughout, bar debugging



**What could have been improved upon**

- Code is not refactored
  - could have made a better effort to keep code concise and refactor throughout the process
- bugs and debugging should have been documented more frequently
- planning before first sprint should have been more thorough
  - GUI wasn't planned
  - first ERD was not good enough, nor sufficient, for the project scope
- testing could have been more thorough
- GUI could update automatically, sometimes when closing a window the GUI only updates once you have done further operations



**Moving forward**

Given further sprints, the first thing I would do is refactor the code.  There are areas were code is repeated, and this isn't necessary.  I'd like to enhance my database, add more tables and make the business layer more functional.  I didn't manage to move beyond my MVP Project Backlog, so there are some user stories I'd like to be able to add to the functionality.  I need to learn to be more diligent with my commenting of code and documenting of any bugs that arise.

Overall, I am quite proud of my first attempt at a 3 tier application.  The project could have run smoother, and the code could be better, but I am proud I managed to create my MVP and I am pleased with it's functionality. 



*Project Board: Start of Sprint One*

![](https://github.com/alexpmarks7/EventsProject/blob/master/Main%20Project%20Images/startOfSprintOne.PNG)



*Project Board: End of Sprint One*

![](https://github.com/alexpmarks7/EventsProject/blob/master/Main%20Project%20Images/endOfSprintOne.PNG)



*Entity Relationship Diagram: Sprint One*

![](https://github.com/alexpmarks7/EventsProject/blob/master/Main%20Project%20Images/ERD.PNG)



*Project Board: Start of Sprint Two*

![](https://github.com/alexpmarks7/EventsProject/blob/master/Main%20Project%20Images/startOfSprintTwo.PNG)



*Project Board: End of Sprint Two*

![](https://github.com/alexpmarks7/EventsProject/blob/master/Main%20Project%20Images/endOfSprintTwo.PNG)



*Updated ERD*

![](https://github.com/alexpmarks7/EventsProject/blob/master/Main%20Project%20Images/ERD_Updated.PNG)



*Project Board: Start of Sprint Three*

![](https://github.com/alexpmarks7/EventsProject/blob/master/Main%20Project%20Images/startOfSprintThree.PNG)



*Project Board: End of Sprint Three*

![](https://github.com/alexpmarks7/EventsProject/blob/master/Main%20Project%20Images/endOfSprintThree.PNG)



*Class Diagram*

![](https://github.com/alexpmarks7/EventsProject/blob/master/Main%20Project%20Images/ClassDiagram.PNG)





***Note: all bugs are documented on GitHub under Issues***
