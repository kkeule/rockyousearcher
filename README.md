# RockYou Searcher

## About

Hearing in the Media about the massive RockYou2024 leak of 10 billion passwords made me concerned, that my passwords might be on this list. As the file is about 150 GB searching this file posed a bit challenging. So I coded this small csharp program to help me and my friends checking, if our passwords on that list.

## How it works

The program takes at minimum two arguments, the path to a textfile, which is expected to only contain the passwords, and at least one search criteria. There can be several search criteria seperated by space.

Example:
```
rockyousearcher.exe C:\path\to\rockyou2024.txt 123 geheim
```

The search criteria are expected to be at the beginning of each line. If you want to search for similar passwords I had good results with at least 4 leading characters to narrow down the results. The console prints the amount of processed lines as well as results found. After finishing the search it writes a text file with all matching lines and their line numbers.

As I don't have that much experience with C# I used very basic instructions and tried to make the search as fast as possible with that limited knowledge. When using 6 search criteria the program took around 20 Minutes to complete.

If you have any recommendations or suggestions for improvement they're highly appreciated.