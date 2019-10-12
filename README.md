# program-restricter

## Overview
`program-restricter` is a tool for restricting access to programs for users on a Windows machine.

It requires Administrator privileges for usage on other users in the system.


## Usage
`program-restricter [block\unblock] [-u] [Username] [-plfa]` 

> ### Verbs:
> `block - Block program/s for certain user.`
>
> `unblock - Unblock program/s for certian user.`
>
> ### Options:
> `-u , --username - Username to apply operation on.`
>
> `-p, --program - Single program executable name to apply operation on.`
>> `Ex. program-restricter block -u Guest -p chrome.exe`
>
> `-l, --list - Multiple programs executable names to apply operation on, seperated by comma.`
>> `Ex. program-restricter block -u Guest -l notepad.exe,chrome.exe`
>
> `-f, --file - Multiple programs executable names to apply operation on, via file contains line seperated executable names.`
>> `Ex. C:\ex.txt contains notepad.exe and chrome.exe each in his own line, example command should look like this: program-restricter block -u Guest -f C:\ex.txt`
>
> `-a, --all - Apply operation on all programs as possible (Currently working only for unblock verb, for unblocking all currently blocked programs)`
>> `Ex. program-restricter unblock -u Guest -a`
