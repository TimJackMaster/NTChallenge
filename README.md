# NTChallenge

Task: See NTAG_Coding Challenge_dotnet_2022.pdf

Note: As I have only very vague knowledge about Front-End-Topics, I chose to focus on a backend oriented solution.
This results in a few possible changes in design, mainly that the Front-End relies on a Web API to get it's data,
weather it's the Open Weather Map data or a "self hosted DB".

## 1. Concept Creation

In this step I analyzed the general purpose of the tasks ahead. I created a sketch design (see architecture_concept.jpg) for the backend.
I also started this very small documentation of my working steps to for other to understand my original reasoning.

I am using git, with working branches that get merged into a master branch. I would usually have a second branch, staging, for a test enviroment.
I felt this, together with a working pipeline, would be overkill for this task. (Just as a sidenode, I prefer a semilinear history via git rebase, not really neccissary in a one-man-army approach ^^)
