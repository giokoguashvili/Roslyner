import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import MonacoEditor from 'react-monaco-editor';
import axios from 'axios';

export class Roslyner extends React.Component<RouteComponentProps<{}>, { codeResult: string, code: string }> {
    constructor(props: RouteComponentProps<{}>) {
        super(props);
        this.state = {
            codeResult: "Empty",
            code: `using System;
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
}`
        }
    }
    private Run() {
        const model = (this.refs.monaco as any).editor.getModel();
        const value = model.getValue();

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
    private onChange() {
        const model = (this.refs.monaco as any).editor.getModel();
        const value = model.getValue();
        this.setState({ code: value });
    }
    public render() {
        return <div>
            <MonacoEditor
                ref="monaco"
                width="800"
                height="600"
                language="csharp"
                theme="vs-dark"
                onChange={() => this.onChange()}
                value={ this.state.code }
            />
            <div>
                {this.state.codeResult}
            </div>
            <button onClick={ () => this.Run() }>Run</button>
        </div>
    }
}
