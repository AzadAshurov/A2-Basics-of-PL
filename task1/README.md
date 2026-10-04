Investigation of endianness (big/little endian)

Introduction

Computers represent and process data using binary values. Binary code is a digital encoding where it uses a two-symbol system called bits — ‘0’ and ‘1’, to represent text, computer processor instructions, or any other data. For instance, Single-Byte (ASCII uses 7 bits but character is typically stored in an 8-bit byte) is used for standard English characters, numbers, and basic punctuation are represented using the ASCII standard, which contains exactly 1 byte (8 bits) per character. Multi-Byte (Unicode/UTF-8) is used to represent characters from other languages (like Chinese, Arabic, or Cyrillic), emojis, and special symbols. Under UTF-8 encoding, a character can take from 1 to 4 bytes.

Understanding the concept of endianness helps to figure out how different systems manage to read data (bytes) and interpret it.Endianness refers to the order in which a set of bytes is arranged and stored in a computer's memory.When a data type requires multiple bytes to be stored (like a 4-byte integer), the computer must decide whether to store the most significant byte or the least significant byte first.

Big-Endian

In a big-endian system, the most significant byte is stored at the lowest memory address (first in order). The same as humans used to read numbers from left to right. To understand big-endian system better: this how 32-bit integer 0x13435644 would be stored in memory:
Address:   |00| |01| |02| |03|
Data:      |13| |43| |56| |44|
So basically the MOST significant byte (13) is located at lowest memory address.

Little—Endian

In a little-endian system, the least significant byte (the "little end") is stored at the lowest memory address. As an Analogy: Writing the number 123 backwards as 3 2 1. And this is how the same 32-bit integer 0x13435644 would be stored in memory in the case of little—Endian:
Address:   |00| |01| |02| |03|
Data:      |44| |56| |43| |13|
So now the LEAST significant byte (44) is located at lowest memory address.

Comparison

Big-Endian: Easy to read in a memory, because it matches standard left-to-right reading. Used in networking protocols (TCP/IP), mainframes, and older architectures (PowerPC, SPARC).Harder type casting, the 1-byte value is not located at the exact same starting address,so 1-byte character requires an extra address offset calculation.

Little—Endian: Harder to read because the bytes appear backwards to the human eye. Used for modern consumer CPUs (Intel x86/x64, AMD) and mobile processors (ARM running Android/iOS).Easier type casting, the 1-byte value is located  at the exact same starting address.Also little—Endian is faster for multi-precision arithmetic because the CPU can start calculating from the first byte (lowest value).

