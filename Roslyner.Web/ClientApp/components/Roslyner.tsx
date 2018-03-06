import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import MonacoEditor from 'react-monaco-editor';
import axios from 'axios';

export class Roslyner extends React.Component<RouteComponentProps<{}>, { codeResult: String }> {
    constructor(props: RouteComponentProps<{}>) {
        super(props);
        this.state = {
            codeResult: ""
        }
    }
    private Run() {
        const value = `using System;
using Roslyner.Web.Models;

namespace Roslyner.Test
{
    public class Foo : IFoo
    {
        public int Sum(int a, int b)
        {
            return 2 * (a + b);
        }
        public int Method()
        {
            //Console.WriteLine(""Hello from Foo"");
            return 27;
        }
        public void Method1()
        {
        }
    }
}`;

         axios
             .post('/Roslyner/Build', {
                 code : value
             })
             .then((res: any) => {
                 this.setState({ 
                     codeResult: res.data.codeResult 
                 });
             })
             .catch((err: any) => console.log(err));
    }
    
    public render() {
        return <div>
            <MonacoEditor
                ref="monaco"
                width="800"
                height="600"
                language="csharp"
                theme="vs-dark"
                value={`using System;
using Roslyner.Models;

namespace Roslyner.Test
{
    public class Foo : IFoo
    {
        public int Sum(int a, int b)
        {
            return 2 * (a + b);
        }
        public int Method()
        {
            //Console.WriteLine(""Hello from Foo"");
            return 27;
        }
        public void Method1()
        {
        }
    }
}`}
            />
            <div>
                {this.state.codeResult}
            </div>
            <button onClick={ () => this.Run() }>Run</button>
        </div>
    }
}
