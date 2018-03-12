import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import MonacoEditor from 'react-monaco-editor';
import axios from 'axios';

interface IMonacoEditorModel {
    codeResult: string,
    code: string,
}

export class Roslyner extends React.Component<RouteComponentProps<{}>, IMonacoEditorModel> {
    constructor(props: RouteComponentProps<{}>) {
        super(props);
        this.state = {
            codeResult: "Empty",
            code: `using System;

namespace Roslyner.Domain
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
    private run(code: string) {
         axios
             .post('/Roslyner/Build', { code })
             .then((res: any) => {
                 this.setState({ 
                     codeResult: res.data.codeResult 
                 });
             })
             .catch((err: any) => console.log(err));
    }

    private onChange(code: string) {
        this.setState({ code });
    }

    private editorValue(): string {
        return (this.refs.monaco as any).editor.getModel().getValue();
    }

    public render() {
        return <div>
            <MonacoEditor
                ref="monaco"
                width="800"
                height="600"
                language="csharp"
                theme="vs-dark"
                onChange={() => this.onChange(this.editorValue())}
                value={ this.state.code }
            />
            <div>
                {this.state.codeResult}
            </div>
            <button onClick={() => this.run(this.editorValue()) }>Run</button>
        </div>
    }
}
