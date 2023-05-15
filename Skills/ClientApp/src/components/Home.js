import { Component } from 'react';
import SkillList from './skill/skillList';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <>
        <SkillList></SkillList>
      </>
    );
  }
}
