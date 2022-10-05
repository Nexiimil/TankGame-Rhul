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