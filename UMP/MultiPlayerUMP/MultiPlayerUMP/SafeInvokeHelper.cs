/*! 
@author Terence Slot. <Tryan18@gmail.com>
		<http://github.com/tryan18/C#>
@date March 19, 2015
@version 1.0
@section LICENSE

The MIT License (MIT)

Copyright (c) 2013 Terence Slot

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;

public class SafeInvokeHelper
{
    static readonly ModuleBuilder builder;
    static readonly AssemblyBuilder myAsmBuilder;
    static readonly Hashtable methodLookup;

    static SafeInvokeHelper()
    {
        AssemblyName name = new AssemblyName();
        name.Name = "temp";
        myAsmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run);
        builder = myAsmBuilder.DefineDynamicModule("TempModule");
        methodLookup = new Hashtable();
    }

    public static object Invoke(System.Windows.Forms.Control obj, string methodName, params object[] paramValues)
    {
        Delegate del = null;
        string key = obj.GetType().Name + "." + methodName;
        Type tp;
        lock (methodLookup) {
        if (methodLookup.Contains(key)) 
            tp = (Type)methodLookup[key];
        else
        {
            Type[] paramList = new Type[obj.GetType().GetMethod(methodName).GetParameters().Length];
            int n = 0;
            foreach (ParameterInfo pi in obj.GetType().GetMethod(methodName).GetParameters()) paramList[n++] = pi.ParameterType;
            TypeBuilder typeB = builder.DefineType("Del_" +  obj.GetType().Name + "_" + methodName, TypeAttributes.Class | TypeAttributes.AutoLayout | TypeAttributes.Public |  TypeAttributes.Sealed, typeof(MulticastDelegate), PackingSize.Unspecified);
            ConstructorBuilder conB = typeB.DefineConstructor(MethodAttributes.HideBySig | MethodAttributes.SpecialName |            MethodAttributes.RTSpecialName, CallingConventions.Standard, new Type[] { typeof(object), typeof(IntPtr) });
            conB.SetImplementationFlags(MethodImplAttributes.Runtime);
            MethodBuilder mb = typeB.DefineMethod( "Invoke", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig, obj.GetType().GetMethod(methodName).ReturnType, paramList );
            mb.SetImplementationFlags( MethodImplAttributes.Runtime ); 
            tp = typeB.CreateType();
            methodLookup.Add(key, tp);
        }
        }

        del = MulticastDelegate.CreateDelegate(tp, obj, methodName);
        return obj.Invoke(del, paramValues);
    }
}
