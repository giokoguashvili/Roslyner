import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import MonacoEditor from 'react-monaco-editor';
import axios from 'axios';

interface IMonacoEditorModel {
    codeResult: string,
    codeTemplate: string,
}

interface ICodeTemplateResult {
    template: string
}
export class Roslyner extends React.Component<RouteComponentProps<{}>, IMonacoEditorModel> {
    constructor(props: RouteComponentProps<{}>) {
        super(props);


        this.state = {
            codeResult: "Empty",
            codeTemplate: "Empty"
        }

        fetch('api/SampleData/CodeTemplate')
            .then(response => response.json() as Promise<ICodeTemplateResult>)
            .then(data => {
                this.setState({ codeTemplate: data.template });
            });
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

    private onChange(codeTemplate: string) {
        this.setState({ codeTemplate });
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
                value={this.state.codeTemplate }
            />
            <div>
                {this.state.codeResult}
            </div>
            <button onClick={() => this.run(this.editorValue()) }>Run</button>
        </div>
    }
}
