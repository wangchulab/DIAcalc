# DIAcalc
Integrating precursors' intensity from Spectronaut data

# Environment

Microsoft Windows (tested on Windows 7 and 10) and .Net Framework 4.7.2
No non-standard hardware required

# Installation

No installation required. Just unzip the package and open “DIACalc.exe” to start computation.

# Input Format
1.	Extract the samples’ precursor IDs (EG.PrecursorId) along with the corresponding Uniprot IDs (PG.ProteinAccessions) and the intensities (EG.TotalQuantity) from spectronaut output file (.xls) to a new txt file. 
2.	Rename the column header of each sample using the format in the example file. The sample name and replicate number should be separated with “_”.

# Usage

1.	Click the “open file” button to choose the data (in the format that we describe above), and click “open fasta” to choose the database file, which should be the same as that used in database search. The output will be saved at the same path as the data file, unless it’s set by clicking the “save” button.
2.	Input the target modification in the “target” textbox.
3.	Click “calc” and wait for output :-)

# Demo
1.	Select “input.txt” as the input data, and select “Homosapiens.fasta” as the protein database. Input “IA_acid” as the target modification (default). Click “calc” button.
2.	After about 2 min, a file named “input_rep.txt” will be output. It should be the same as “output.txt” provided by us.
