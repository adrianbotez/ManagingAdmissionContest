# ManagingAdmissionContest
Specifications

The application will consist in three modules:

A simple database system
definition of a file format for storing the tables
operations on databases: creation (by defining the tables), deletion; once the database has been created, its structure (and the structure of the tables it contains) will not be modified.
operations on tables: record insertion/deletion/update, selection
A module for input/output management. For both input and output, two of the variants below must be implemented (may be different for input and output, respectively):
web interface
user dialogs
files: text, Excel, PDF, HTML, ...
etc.
A module that carries out the operations required by the admission process:
data input
compute the candidates' results
classify the candidates: budget-financed / fee payer / rejected
publish the results
Permanent communication with the beneficiary is necessary, so feel free to ask any questions you may have about the requirements. Programs that do not do what they are supposed to, due to misunderstanding the requirements, will be penalized.

The recommended programming languages are C# and Java. It is however allowed to choose any other language, provided it has unit testing and mocking tools, as well as assertions (which must be language-specific, apart from unit testing assertions); all these will be necessary during the next phases.

It is recommended to design a program structure as simple as possible, without including any additional features than the ones mentioned above. The goal is to create a working version of the program, not necessarily fully stable or error-free, on which testing techniques will subsequently be applied.

The access to the database will be low-level, without using specialized libraries (e.g., for parsing XML files).

Throughout the project phases it is also necessary to write the documentation, which will be delivered in the final phase.
