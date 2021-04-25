# LD3-4
integruotų programavimo aplinkų laboratoriniai darbai

release v0.4

-added option to generate 4 files with 10,000, 100,000, 1,000,000 and 10,000,000 records.
-add option to split generated file into two: a list of students that failed and a list of students that passed.
-for some reason, a bug appeared in this release that would make the files not generate the entire 10k or 100k (and so on) records, it would stop at like 9998, in order for the program to work, i had to go into the generated files and remove the last line manually, since it would be something like "surname9998 name9998 1 2" and would fail to generate the rest.
