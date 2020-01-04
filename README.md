# BEMUCPU
Bad Emulated CPU

Based on the work of Ben Eater and Albert Paul Malvino (Digital computer electronics). Reboot of a previous project titled "BCPU"

BEMUCPU is an (work-in-progress) emulated 16 bit CPU with EEPROM based ROM and SRAM based RAM, EEPROM based control logic, LCD display, and more. This emulator is written in C#, offering realtime execution. The emulator is to help work out some of the organizational kinks before building the entirety of the CPU (though some parts can be independently built). It will also serve to simplify the process of programming the microcode into the control logic EEPROMs, and to write and test programs that will run on the CPU.

This is still a work in progress, as I have started development from scratch.

### CPU Features
- 16 bit data bus, instructions
- A and B registers
- Conditional Jumps
- Hardware Stack
- 16 bit ALU consisting of 4 x 74LS181, 1 x 74LS182 ALU

### Emulator Features
- Emulates submodules (RAM, ROM, Registers, Bus, etc.).

### Planned Features
- Variable real-time clock speed
- Display of the state of each submodule for debugging programs
- Custom Assembly language compiled to binary
