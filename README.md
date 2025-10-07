# Repository Overview

This repository contains a small demo showcasing a UI behavior scenario.

I’ve added several buttons to the interface. Depending on certain conditions, some buttons can be interacted with, while others cannot. When a button is disabled, I wanted to give users a clear explanation of why it’s unavailable.

To do this, I wrapped each button inside a Badge control. When interaction is not allowed, a badge is displayed along with a tooltip text describing the reason.

In some cases, the same rule applies to multiple buttons. To keep things consistent, I decided to reuse the same badge and tooltip string across them — so the user sees a unified explanation.

However, when I tried binding the same PackIcon instance to multiple badges in XAML, I noticed that only the first button’s badge displayed the icon correctly. The others showed no icon at all.

I’m wondering if this behavior is related to object instancing, or if there’s something else I’m missing. I’d really appreciate any feedback or explanation about why this happens!

Feel free to review it or even go over it on stream — I don’t mind at all 🙂
Thank you!

# Usage of demo
Click on "Click Me" button to make the buttons non-available.

# Bonus
Not at all related to the badge problem. Updating to the latest MDIX, I observed that with every Combobox I add to my UI it comes with a binding error now. I have added one in here to.
The binding error is : "System.Windows.Data Error: 5 : Value produced by BindingExpression is not valid for target property. null BindingExpression:Path=(0); DataItem='ComboBox' (Name=''); target element is 'ComboBox' (Name=''); target property is 'Name' (type 'String')"
