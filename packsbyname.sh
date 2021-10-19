#!/bin/bash

echo
echo "Finding packages by name."
echo "Using 'yay -Ss' for searching."
echo

TmpFile=".out.tmp"

if [ -z $1 ]
then
    echo "No required script parameters! Use 'packsbyname --help' for more info."
    exit
fi

if [ $1 == "--help" ]
then
    echo "Script with application is used for searching packages databes only by packages names. It ignores search hits in packages description."
    exit
fi

yay -Ss $1 >> $TmpFile

#unhash in development mode
dotnet run $TmpFile $1

#hash in development mode
#packsbyname $TmpFile $1

rm $TmpFile
