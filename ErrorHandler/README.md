# Fitz Utilities ErrorHandler
A simple error tracking package

## Purpose
Holds a collection of Errors in the form of Errors and Warnings to be accumulated by functions

## Usage
### Creating an ErrorHandler
```cs
ErrorHandler errors = new ErrorHandler();
```

### Adding Errors / Warnings
```cs
string id = "UsbNotOpen"
string message = "USB Failed to Open."

errors.AddError(id, message); // Add Error with an Id and Message
errors.AddWarning(id, message); // Add Warning with an Id and Message
```

### Combine Errors and Warnings
```cs
ErrorHandler errors1 = new ErrorHandler();
ErrorHandler errors2 = new ErrorHandler().AddError("UsbNotOpen", "USB Failed to Open");

errors1 += errors2;
```

### Checking
```cs
bool AnyErrorsOrWarnings = errors.HasAny(); // Returns True if Any Errors or Warnings Exist
bool AnyWarnings = errors.HasWarnings(); // Returns True if Any Warnings Exist
bool AnyErrors = errors.HasErrors(); // Returns True if Any Errors Exist
```

### Clearing
```cs
errors.Clear(); // Clear Errors and Warnings
errors.ClearWarnings(); // Clears Warnings
errors.ClearErrors(); // Clears Errors
```

### Iterating
```cs
foreach (IError error in errors.Errors) {}
foreach (IError warning in errors.Warnings) {}
```