# 2D-GameRPG-Concept



HI,

first of all,the project is complete mess and its done without any structure nor any artitecture,its complete mess,sorry for that.


The levels are not complete nor finished and i have removed all the latest mechanisms we have added as it is confusing and creating bugs.
so this is the simplest form of the game..i will update the project after sorting and fixing the bugs and cleaning up a bit..

currently we are working on a node based dialogue manager using graphview, but for now the game uses simple index referencing,

the first npc (the pirate/captain) uses a diffrent script from the rest for conversation...since they asked me to complete this in a week and sincce it is just a prototype i just went with simpler hacks to just finish a level of the  game;

currently the question_manager is not singleton,but reside within the npc or interactable gameobjects(the objects that asks questions)...i did it that way because for the prototype i wanted each character to have distinctive background for question ui,and it was less work this way,but i have already implemented a sigleton central Questionmanager that can pass the question to characters but i have removed it..for now...
 


													
© 2021 GitHub, Inc.
sravanDas#

 
