# Git Practice for Testers

This PowerShell transcript demonstrates checking repository status, staging and committing work, pushing and pulling changes, and creating, switching, and deleting a branch:

```powershell
PS C:\Users\minha\Documents\atib\Gateway-Training> git status
On branch main
Your branch is up to date with 'origin/main'.

Untracked files:
  (use "git add <file>..." to include in what will be committed)
        Week1/Day4/

nothing added to commit but untracked files present (use "git add" to track)
PS C:\Users\minha\Documents\atib\Gateway-Training> git add .
PS C:\Users\minha\Documents\atib\Gateway-Training> git commit -m "Add Day 4 C# login testing program using OOP concepts"
[main 3adad98] Add Day 4 C# login testing program using OOP concepts
 4 files changed, 152 insertions(+)
 create mode 100644 Week1/Day4/ProgrammingForTesters/LoginPage.cs
 create mode 100644 Week1/Day4/ProgrammingForTesters/LoginTests.cs
 create mode 100644 Week1/Day4/ProgrammingForTesters/Program.cs
 create mode 100644 Week1/Day4/ProgrammingForTesters/ProgrammingForTesters.csproj
PS C:\Users\minha\Documents\atib\Gateway-Training> git push
Enumerating objects: 11, done.
Counting objects: 100% (11/11), done.
Delta compression using up to 4 threads
Compressing objects: 100% (8/8), done.
Writing objects: 100% (9/9), 1.56 KiB | 106.00 KiB/s, done.
Total 9 (delta 2), reused 0 (delta 0), pack-reused 0 (from 0)
remote: Resolving deltas: 100% (2/2), completed with 2 local objects.
To https://github.com/Atibali/Gateway-Training.git
   65bc6a9..3adad98  main -> main
PS C:\Users\minha\Documents\atib\Gateway-Training> git pull
Already up to date.
PS C:\Users\minha\Documents\atib\Gateway-Training> git branch
* main
PS C:\Users\minha\Documents\atib\Gateway-Training> git switch -c day4-testing
fatal: a branch named 'day4-testing' already exists
PS C:\Users\minha\Documents\atib\Gateway-Training> git switch  day4-testing
Already on 'day4-testing'
PS C:\Users\minha\Documents\atib\Gateway-Training> git switch main
Switched to branch 'main'
Your branch is up to date with 'origin/main'.
PS C:\Users\minha\Documents\atib\Gateway-Training> git branch
  day4-testing
* main
PS C:\Users\minha\Documents\atib\Gateway-Training> git branch -D day4-testing
Deleted branch day4-testing (was 3adad98).
PS C:\Users\minha\Documents\atib\Gateway-Training> git branch
* main
PS C:\Users\minha\Documents\atib\Gateway-Training>
```
