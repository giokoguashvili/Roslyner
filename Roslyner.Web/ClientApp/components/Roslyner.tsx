import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import MonacoEditor from 'react-monaco-editor';
import axios from 'axios';

interface IMonacoEditorModel {
    codeResult: string,
    codeTemplate: string,
}

interface IBuildResult {
    codeResult: string
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

        axios
            .get("api/SampleData/CodeTemplate")
            .then(res => res.data as ICodeTemplateResult)
            .then(data =>
                this.setState({
                    codeTemplate: data.template
                })
            );
    }

    private run(code: string) {
        axios
            .post('/Roslyner/Build', { code })
            .then(res => res.data as IBuildResult)
            .then(data => {
                this.setState({
                    codeResult: data.codeResult
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
                       value={this.state.codeTemplate}/>
                   <button onClick={() => this.run(this.editorValue())}>Run</button>
                   <div>
                       {this.state.codeResult}
                   </div>
               </div>;
    }
}
