// Dispatcher: pick a lesson by name. Default = HelloWorld.
var lesson = args.Length > 0 ? args[0] : "HelloWorld";
var lessonArgs = args.Skip(1).ToArray();

switch (lesson.ToLowerInvariant())
{
    case "helloworld":       HelloWorldLesson.Run(lessonArgs); break;
    case "typesandvariables":TypesAndVariablesLesson.Run(lessonArgs); break;
    case "typeconversion":   TypeConversionLesson.Run(lessonArgs); break;
    case "operators":        OperatorsLesson.Run(lessonArgs); break;
    case "methods":          MethodsLesson.Run(lessonArgs); break;
    case "strings":          StringsLesson.Run(lessonArgs); break;
    case "collections":      CollectionsLesson.Run(lessonArgs); break;
    case "controlflow":      ControlFlowLesson.Run(lessonArgs); break;
    default:
        Console.WriteLine("Unknown lesson. Try: HelloWorld, TypesAndVariables, TypeConversion, Operators, Methods, Strings, Collections, ControlFlow");
        break;
}