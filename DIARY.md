# Project Diary - Building a Game
## 28/09/2022
This diary has been created to keep myself in line with my goals, as well as actually being able to outline them here over time. Currently, i have:
 - A project plan draft with all the key sections
 - This repo cloned for editting .md files in VSCode
 - Some small collection of papers/books/games for reserach and analysis
 - A proof of concept for auto-tiling rooms correctly in Unity
 - A loose game design document
 - ideas i havent writen out, which im gonna do below

What i am doing right now:
 - The second draft of my project plan, tuning back the abstract, because its a page long
 - Figuring out how i want to format this diary
 - Getting unity to work with this gitlab repo

Final goals:
 - A game with some form of PCG, a character to navigate with, and enemies to defeat
 - A detailed report on all the complexities of the above task, especially noting all the ==Design Patterns==

 ---
## 29/09/2022
I have modified my initial draft of my project plan, replacing the risk table for a more verbose risk assessment section. I have inserted a gantt chart, and further broken down my almost biweekly/triweekly time plan into a weekly breakdown, bar 2 weeks, in which coding large sections of the final game may take much more time and effort.

---
## 02/10/2022
Handed in my second draft of my project plan to my supervisor, with much more detail on what i will be using to do my research, what proof on concepts, reports and test tools i will be writing, and have written notes next to each of my milestones as to why each one is important. I will commit it to my Gitlab once it has been looked over tomorrow, in my meeting with Hugh.

---
## 03/10/2022

### Meeting notes

Two things to note

    Abstract:
        Acts like a pre-summary, 2 paragraphs
        Sentence 1: purpose of the paper
        Sentence 2: what it contains

    Bibliography:
        References and bibliography could serve as 1

---
## 04/10/2022

Uploaded my current unity files to the repo, realised that it was trying to sync my Library files, which unity generates itself, to the repo as well, which was trying to commit 10k file changes, which is not ideal, so a .gitignore was also added to make sure there was no issue. Was quite scary to see 10k additions. Turns out it was only about 150 files instead, and i dont think i even needed to commit my logs, or usersettings folders, but figured since nothing online mentioned it, i would simply commit them anyways, i can remove them later if they become an active issue.

---
## 05/10/2022
managed to complete a proof of conecpt, i have all basic motion and collision sorted, i now just need to focus on research and the further proof of concepts until i have a prototype. The prototype should be super required until my interim, but the prood of concept is good for my next meeting with Hugh. Next bit of research i will focus on is likely the major elements of a roguelike game, just so i can have everything i need infront of my when developing proofs of concpets, because in thoery all proofs can be derived from that bit of research in some form.

---
## 07/10/2022
Made some tweeks to accomodate for a slight bug in the collision on my proof of concept, and i understand now why the bug existed too.

---
## 10/10/2022
 I have done some product research that i will upload very soon, as its almost finished. I currently am also working on a document that would outline the thoeretical algorithms and structures i would be able to apply to my project, allowing me to place my thoughts onto a single document that i can go back to whenever i need. I may have both of these documents converted into markdown, for a similar format to what i have in this diary here. These bits of research can later be translated to LaTeX, but i currently use VsCode to write this diary, which syncs to the gitlab repo for me, and if im writing my history into that repo, writing my research bit by bit is doing exactly that, rather than writing into google docs and transfering it over in pdf form when im finished.

 ---
 ## 18/10/2022
 After 8 days of little to show for myself i have reminded myself i need to actually update this diary and the gitlab in order for progress to be made. doing things on my own machine doesnt mean much if the history cant be seen, so i am uploading the current state of notes into the notes section. I may have to reorganise them later if i add to them in the future.

 ---
 ## 19/10/022
 I have finalised the roation method for enemeies to envoke, in order to track the player. It was very difficult, and requried me to learn about quaternions, which are really not very fun to learn about either, i will need to explain these in my vive, but roughly, its a method to rotate a 3D object using 4 dimensions, x,y,z, and an additional w imaginary number. It is not directly linked to Euler rotation with degrees, and i need to convert euler rotations to Quaternions to use them on my transforms.

 ---
 ## 21/10/2022
 I have begun work on a damage system for the proijecftiles that the player and the enemies can shoot. Main issue right now is that the projeciles will also be able to collide, and i have realised that my code is less than ideal modularity wise, so i will need to a small refactor ro make sure i am not depending on single classes for many functions, this is not how Dave taught me, and i intend to correct for this.

 ---
 ## 25/10/2022
 ### Meeting Notes
 Hugh mentioned that i have no real evidence of formal testing, which is true. I need to outline how i am doing my testing, as i have actually been doing it, but it isnt very obvious at all. Essentially, sinc ei cannot isolate my scripts from the game environment, i will need to write tests that i can perform in the game, therefore acting as unity tests. I do also need to start writing my document in which i breakdown my required design patterns, a UML may go will with this.

 ## 28/10/2022
 I have finished the damage system, and finally gotten round to updating my diary, again, as i had forgotten. The refactor is next on the list to do, which i should be able to do very soon. I will need to work on a simple item system within the next 2 weeks. This is a very achievable task.