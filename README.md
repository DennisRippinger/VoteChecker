# VoteChecker

## Basics

The main goal is to enable the canvassers to quickly process a large number of ballots with a unique barcode to ensure it's valid. A ballot is valid if the string or number that the barcode represents, is known to the election committee. (See [Ballot Generator](https://github.com/DennisRippinger/BallotGenerator) for more information). When a valid barcode is scanned, the Background turns green. An already scanned barcode (a pure copy) will turn the background red. At least, an unknown barcode is represented as yellow background (maybe an attempt to election fraud).

In case a ballot occurs twice or more - all of them has to be removed from the election. To identify them the receive an individual number. Based on GroupID-Package-Item. It is likley that more than on group is scanning the barcodes, so there is a selection of groups. Each group has several packages. If a ballot now turns to be invalid, the first occurrence of it can be easily identified. 

## XML-Config

VoteChecker has a small number of options that can be alterd in an XML file. These are the following:
* Group: The individual canvasser - or group - working on a single PC.
* Database IP: The IP of the Database
* DatabaseUser: The Username
* DatabasePW: The corresponding Password
* Limit: When the Limit of a Packet is reached, a Dialog pops up to inform the canvasser to change the packet.

## Database

The Database consists of just one table. The Rows are:

Barcode - Checked - Group_Number - Packet - Item - Timestamp
* Checked indicates if the Ballot has already been processed.
* Group_Number shows the number of the group.
* Packet represents the number of the packet a processed ballot is in.
* Item is the number of the Ballot.

A demo dump of the database can be found inside the project folder.
