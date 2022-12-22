import { useState } from "react";
import { Message } from "semantic-ui-react";

interface Props {
    errors: any;
}

export default function ValidationError({ errors }: Props) {
    let raktai = '';
    for (var key in errors.response.data.errors) {
        raktai = key;
    }

    return (
        <Message error>
            <Message.Item>
                {errors.response.data.errors[raktai]}
            </Message.Item>
        </Message>

    )
}