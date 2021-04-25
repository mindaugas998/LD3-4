- the program has a console menu programmed within itself, so all tasks can be completed via that menu.

- - v0.1

- added option to add a student

- added final points calculation function

- added option to print all students

- added option to print all students with median

- added option to add students that are randomly generated
----------------------------------------------------------------
- v0.2

- added ability to read from file
----------------------------------------------------------------
- v0.3

- added try catch blocks in printing functions and reading data from file function
----------------------------------------------------------------
- v0.4

- added option to generate 4 files with 10,000, 100,000, 1,000,000 and 10,000,000 records.
- add option to split generated file into two: a list of students that failed and a list of students that passed.
- for some reason, a bug appeared in this release that would make the files not generate the entire 10k or 100k (and so on) records, it would stop at like 9998, in order for the program to work, i had to go into the generated files and remove the last line manually, since it would be something like "surname9998 name9998 1 2" and would fail to generate the rest.

----------------------------------------------------------------
- It took 7873 miliseconds to create and fill all files.
- It took 9 miliseconds to create 10 000 records.
- It took 65 miliseconds to create 100 000 records.
- It took 728 miliseconds to create 1 000 000 records.
- It took 7065 miliseconds to create 10 000 000 records.

----------------------------------------------------------------
- v0.5
List<>

- Time elapsed to divide 10k records: 14 ms
- Time elapsed to output divided 10k records: 7 ms
----------------------------------------------------------------
- Time elapsed to divide 100k records: 146 ms
- Time elapsed to output divided 100k records: 68 ms
----------------------------------------------------------------
- Time elapsed to divide 1 million records: 1757 ms
- Time elapsed to output divided 1 million records: 611 ms
----------------------------------------------------------------
- Time elapsed to divide 10 million records: 18749 ms
- Time elapsed to output divided 10 million records: 5897 ms


Queue<>

- Time elapsed to divide 10k records: 13 ms
- Time elapsed to output divided 10k records: 8 ms
----------------------------------------------------------------
- Time elapsed to divide 100k records: 145 ms
- Time elapsed to output divided 100k records: 63 ms
----------------------------------------------------------------
- Time elapsed to divide 1 million records: 1698 ms
- Time elapsed to output divided 1 million records: 569 ms
----------------------------------------------------------------
- Time elapsed to divide 10 million records: 18027 ms
- Time elapsed to output divided 10 million records: 5797 ms

LinkedList<>
- Time elapsed to divide 10k records: 15 ms
- Time elapsed to output divided 10k records: 8 ms
----------------------------------------------------------------
- Time elapsed to divide 100k records: 159 ms
- Time elapsed to output divided 100k records: 74 ms
----------------------------------------------------------------
- Time elapsed to divide 1 million records: 1796 ms
- Time elapsed to output divided 1 million records: 573 ms
----------------------------------------------------------------
- Time elapsed to divide 10 million records: 18485 ms
- Time elapsed to output divided 10 million records: 5827 ms

